using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.IRepository;

namespace InsteadBuyPlatform.Controllers
{
    /// <summary>
    /// 客户
    /// </summary>
    public class ClientInfoController : BaseController
    {
        IClientInfoRepository _clientInfoRepository;

        public ClientInfoController(IClientInfoRepository clientInfoRepository)
        {
            _clientInfoRepository = clientInfoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新增客户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult Add(ClientInfo model)
        {
            model.IsDel = false;
            model.CreateTime = DateTime.Now;
            model.UserId = CurrentUser.Id;
            model.UpdateTime = DateTime.Now;

            try
            {
                _clientInfoRepository.Add(model);
                return JsonOk("");
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult Modify(ClientInfo model)
        {
            try
            {
                var oldModel = _clientInfoRepository.GetSingle(model.Id);
                oldModel.UpdateTime = DateTime.Now;
                oldModel.ProvinceName = model.ProvinceName;
                oldModel.ProvinceCode = model.ProvinceCode;
                oldModel.DetailedAddress = model.DetailedAddress;
                oldModel.CountyName = model.CountyName;
                oldModel.CountyCode = model.CountyCode;
                oldModel.ClientPhone = model.ClientPhone;
                oldModel.ClientName = model.ClientName;
                oldModel.CityName = model.CityName;
                oldModel.CityCode = model.CityCode;
                _clientInfoRepository.Update(oldModel);
                return JsonOk("");
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            try
            {
                var oldModel = _clientInfoRepository.GetSingle(id);
                oldModel.IsDel = true;
                _clientInfoRepository.Update(oldModel);
                return JsonOk("");
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        /// <summary>
        /// 获取联系人前8条
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IActionResult GetListByKey(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return JsonOk(_clientInfoRepository.FindBy(e => e.UserId == CurrentUser.Id && e.IsDel == false).Take(8).ToList());
            }
            else
            {
                return JsonOk(_clientInfoRepository.FindBy(e => e.UserId == CurrentUser.Id && e.IsDel == false && e.ClientName.Contains(key)).Take(8).ToList());
            }
        }
    }
}