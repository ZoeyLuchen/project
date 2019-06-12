import execjs
import requests
import uuid
from bs4 import BeautifulSoup
import sys;
import re;

sys.path.append('Common/')
import RequestsHelper;
import Common;
sys.path.append('DataAccessLayer/')
# from DataAccessLayer import ReptileDataUpdata;
from ReptileDataUpdataFile import ReptileDataUpdata

siteUrl = "https://www.700du.cn/"

InsurerCompanyInfo = [];#保险公司集合
InsuranceType = [];#保险类型集合
ConsumptionType = [{"TypeName":"分红型","Id":uuid.uuid1()},{"TypeName":"返现型","Id":uuid.uuid1()},{"TypeName":"消费型","Id":uuid.uuid1()}];#消费类型集合
ProductList=[]; #产品集合
SellingPoint =[] #产品卖点
#Product_Ptl=[]#产品保障期间关系表
#ProtectionTimeLimit=[]#保障期限表
ProductServiceInfo=[]#产品服务表
Product_Service=[]#产品服务关系表

print(ConsumptionType)

def getSiteUrlParams(text):
    paramList = [];
    bsObject = BeautifulSoup(text, 'lxml')
    mainMune = bsObject.find_all("dl", class_="y_pctreedl");
    for cMain in mainMune:
        src = cMain.find("a")["href"]

        paramStr =  src[src.index('?')+1:]+"&";
        param = {};
        param["categoryUuid"] = paramStr[paramStr.index('categoryUuid=') + 13:paramStr.index('&', paramStr.index('categoryUuid='))]
        param["storeUuid"] = paramStr[paramStr.index('storeUuid=')+10:paramStr.index('&',paramStr.index('storeUuid='))]
        paramList.append(param)
        InsuranceType.append({"TypeName": cMain.find("a").get_text().strip(), "Id": uuid.uuid1(),"categoryUuid":param["categoryUuid"]})
    return paramList;

def getProductData(url,param):
    text = RequestsHelper.postAsync(url,param,"utf-8").text;

    bsObject = BeautifulSoup(text, 'lxml');
    pageCountText = bsObject.find(class_="page-skip").em.get_text();
    pageCount = pageCountText[pageCountText.index('共')+1:pageCountText.index('页')]
    #print(pageCount)
    for i in range(int(pageCount)):
        param["nowPage"] = i+1;
        text = RequestsHelper.postAsync(url, param, "utf-8").text;
        bsObject = BeautifulSoup(text, 'lxml');
        productItem = bsObject.find_all(class_="product-item");

        for item in productItem:
            companyLogo = item.find(class_="company-logo").img["src"];
            company = {};
            for d in InsurerCompanyInfo:
                if d["CompanyLogo"] ==companyLogo:
                    company = d;
            if company == {}:
                company["Id"] = uuid.uuid1();
                company["CompanyLogo"] = companyLogo;

            product = {};
            product["Id"] = uuid.uuid1();
            product["CompanyId"] = company["Id"];
            f24 = item.find(class_="f24");
            product["ProductName"] =f24.get_text().strip();
            product["DetailUrl"] = siteUrl+f24["href"];
            product["OutSiteKey"] = f24["href"][Common.find_last(f24["href"],"/")+1:];
            product["Pic"] = item.find(class_="prod-pic").img["src"];

            #保险类型查询
            for i in InsuranceType:
                if i["categoryUuid"] == param["categoryUuid"]:
                    product["InsuranceTypeId"] = i["Id"];

            firstListItem = item.find(class_="list").li;
            ageText = firstListItem.find(class_="list-title").get_text()[7:];#获取 56岁~80岁
            nums = re.findall(r"\d+\.?\d*",ageText);
            texts = re.findall(r"[\u4e00-\u9fa5]",ageText);
            product["BeginAge"] = nums[0];
            product["EndAge"] = nums[1];
            product["BeginAgeUnit"] = 1 if texts[0] == "天" else (2 if texts[0] == "岁" else 0) ;
            product["EndAgeUnit"] = 1 if texts[0] == "天" else (2 if texts[0] == "岁" else 0);

            timeLimitText=firstListItem.find(class_="list-content").get_text()[5:] #获取 1年
            product["TimeLimit"] = timeLimitText;
            product["IsDisable"] = False;
            product["LowestPrice"] = item.find(class_="f30").get_text();

            #产品卖点
            listItemList = firstListItem.next_siblings;
            for li in listItemList:
                if li.name != "li":
                    continue;
                listItem = {};
                listItem["ProductId"] = product["Id"];
                listItem["SpName"] = li.find(class_="list-title").get_text().strip();
                listItem["SpDesc"] = li.find(class_="list-content").get_text().strip();
                listItem["Id"] = uuid.uuid1();
                SellingPoint.append(listItem);

            #插入产品服务及产品服务关系表
            impressionList = item.find_all(class_="impression-item");
            for li in impressionList:
                impression = {};
                for it in ProductServiceInfo:
                    if(it["ServiceName"] == li.get_text().strip()):
                        impression = it;
                if impression =={}:
                    impression["Id"] = uuid.uuid1();
                    impression["ServiceName"] = li.get_text().strip();
                    impression["IsDisable"] = False;
                    ProductServiceInfo.append(impression);
                Product_Service.append({"ProductId":product["Id"],"ServiceId":impression["Id"]});

            ProductList.append(product);

            if  ('CompanyName' in company) == False:
                text = RequestsHelper.get(product["DetailUrl"], {}, "utf-8").text
                po = BeautifulSoup(text, 'lxml');
                context = po.find(id="y_prodsingle").get_text();
                print(context);
                try:
                    company["CompanyName"] = re.findall(".*由(.*)承保.*", context[:80])[0].strip()
                    company["IsDisable"] = False;
                    InsurerCompanyInfo.append(company);
                except :
                    company["CompanyName"] = re.findall(".*【保险公司】(.*)于.*", context[:80])[0].strip();
                    company["IsDisable"] = False;
                    InsurerCompanyInfo.append(company);
                    #print(context)
            #print(InsurerCompanyInfo);
            # print(InsuranceType);
            # print(ProductList);
            # print(SellingPoint);
            # print(ProductServiceInfo);
            # print(Product_Service);

if __name__ == "__main__":
    text = RequestsHelper.get(siteUrl,{},"utf-8").text;
    paramList = getSiteUrlParams(text);
    # print(paramList);

    # for param in paramList:
    #     param["nowPage"] = 1;
    #     getProductData(siteUrl+"/front/productList/queryStoreProductList",param);
        #print(param)
    getProductData(siteUrl + "/front/productList/queryStoreProductList", paramList[0]);

    print(InsurerCompanyInfo);
    print(InsuranceType);
    print(ProductList);
    print(SellingPoint);
    print(ProductServiceInfo);
    print(Product_Service);

    rdu = ReptileDataUpdata();
    rdu.addInsurerCompany(InsurerCompanyInfo);
    rdu.addInsuranceType(InsuranceType);
    rdu.addProductList(ProductList);
    rdu.addSellingPoint(SellingPoint);
    rdu.addProductServiceInfo(ProductServiceInfo);
    rdu.addProduct_Service(Product_Service);
