import sys
sys.path.append('../Common/')
from MsSqlHelper import sqlHelper;

class ReptileDataUpdata:
    #获取目前所有可用企业
    def getAllInsurerCompany(self):
        sh = sqlHelper;
        sql = "select * from InsurerCompanyInfo where IsDisable = 0";
        rs = sh.executSql(sql);
        sh.conn.close();
        print(rs);
        return list(rs);

    #返回所有保险类型数据
    def getAllInsuranceType(self):
        sh = sqlHelper;
        sql = "select * from InsuranceType where IsDisable = 0";
        rs = sh.executSql(sql);
        sh.conn.close();
        print(rs);
        return list(rs);

    #返回所有产品数据
    def getAllProducts(self):
        sh = sqlHelper;
        sql = "select * from ProductList where IsDisable = 0";
        rs = sh.executSql(sql);
        sh.conn.close();
        print(rs);
        return list(rs);

    #返回所有产品卖点
    def getAllSellingPoint(self):
        sh = sqlHelper;
        sql = "select * from SellingPoint where IsDisable = 0";
        rs = sh.executSql(sql);
        sh.conn.close();
        print(rs);
        return list(rs);

    # 返回所有产品服务信息
    def getAllProductServiceInfo(self):
        sh = sqlHelper;
        sql = "select * from ProductServiceInfo where IsDisable = 0";
        rs = sh.executSql(sql);
        sh.conn.close();
        print(rs);
        return list(rs);

    #添加公司
    def addInsurerCompany(self,items):
        addItems = [];
        sh = sqlHelper();
        sh.createConnect();
        try:
            for item in items:
                rs = sh.executeScalar("select count(*) from InsurerCompanyInfo where CompanyName =%s",item["CompanyName"]);
                print(rs);
                if(rs == 0):
                    addItems.append(tuple(item.values()));
            if len(addItems)>0:
                sh.executeNonQuery("insert into InsurerCompanyInfo (Id,CompanyLogo,CompanyName,IsDisable) values(%s,%s,%s,%s)",addItems)
                sh.conn.commit();
            return True;
        except Exception as e:
            sh.conn.rollback();
            return e
        finally:
            sh.conn.close();

    #添加公司
    @classmethod
    def addInsuranceType(self,items):
        addItems = [];
        sh = sqlHelper();
        sh.createConnect();
        try:
            for item in items:
                rs = sh.executeScalar("select count(*) from InsurerCompanyInfo where CompanyName =%s",item["CompanyName"]);
                print(rs);
                if(rs == 0):
                    addItems.append(tuple(item.values()));
            if len(addItems)>0:
                sh.executeNonQuery("insert into InsurerCompanyInfo (Id,CompanyLogo,CompanyName,IsDisable) values(%s,%s,%s,%s)",addItems)
                sh.conn.commit();
            return True;
        except Exception as e:
            sh.conn.rollback();
            return e
        finally:
            sh.conn.close();
