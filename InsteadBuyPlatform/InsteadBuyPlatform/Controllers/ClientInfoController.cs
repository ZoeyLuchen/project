﻿using System;
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
        /// 查询数据列表
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public IActionResult SearchListByPage(ClientInfoParam param, PageInfo pageInfo)
        {
            param.UserId = CurrentUser.Id;

            var result = _clientInfoRepository.SearchListByPage(param, pageInfo);
            return Json(result);
        }

        /// <summary>
        /// 新增客户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult Add([FromBody]ClientInfo model)
        {
            try
            {
                if (_clientInfoRepository.Count(e => e.ClientName == model.ClientName && e.UserId == CurrentUser.Id && e.IsDel == 0) > 0)
                {
                    return JsonError("客户名重复");
                }

                model.IsDel = 0;
                model.CreateTime = DateTime.Now;
                model.UserId = CurrentUser.Id;
                model.UpdateTime = DateTime.Now;

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
        public IActionResult Modify([FromBody]ClientInfo model)
        {
            try
            {
                if (_clientInfoRepository.Count(e => e.ClientName == model.ClientName && e.Id != model.Id && e.UserId == CurrentUser.Id && e.IsDel == 0) > 0)
                {
                    return JsonError("客户名重复");
                }

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
        public IActionResult Delete([FromBody]ClientInfo model)
        {
            try
            {
                var oldModel = _clientInfoRepository.GetSingle(model.Id);
                oldModel.IsDel = 1;
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
            IEnumerable<ClientInfo> list ;

            if (string.IsNullOrEmpty(key))
            {
                list = _clientInfoRepository.FindBy(e => e.UserId == CurrentUser.Id && e.IsDel == 0).Take(8).ToList();
            }
            else
            {
                list = _clientInfoRepository.FindBy(e => e.UserId == CurrentUser.Id && e.IsDel == 0 && e.ClientName.Contains(key)).Take(8).ToList();
            }

            List<dynamic> dyList = new List<dynamic>();

            list.ToList().ForEach(e =>
            {
                dyList.Add(new { value = e.ClientName, id = e.Id});
            });

            return JsonOk(dyList);
        }
    }
}