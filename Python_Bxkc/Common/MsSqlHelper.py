import pymssql

class sqlHelper:
    def __init__(self):
        self.host = "127.0.0.1";
        self.user ="sa";
        self.password  ="Abc123456";
        self.database ="Bxkc";
        self.timeout = 0;
        self.login_timeout = 60;
        self.charset = "utf8";
        self.as_dict = False;

    def createConnect(self):
        conn = pymssql.connect(host=self.host,user=self.user,password=self.password,database=self.database,timeout=self.timeout,login_timeout=self.login_timeout,charset=self.charset,as_dict=self.as_dict);
        self.conn = conn;

    #查询sql,返回第一行第一列
    def executeScalar(self,sql):
        cursor = self.conn.cursor();
        try:
            cursor.execute(sql);
            rs = cursor.fetchone();
            if(len(rs)>0):
                return rs[0];
            else:
                return None;
        except Exception as e:
            return e
        finally:
            cursor.close();

    #查询sql,返回第一行第一列
    def executeScalar(self,sql,param):
        cursor = self.conn.cursor();
        try:
            cursor.execute(sql,param);
            rs = cursor.fetchone();
            if(len(rs)>0):
                return rs[0];
            else:
                return None;
        except Exception as e:
            return e
        finally:
            cursor.close();

    #返回受影响的行数
    def executeNonQuery(self,sql):
        cursor = self.conn.cursor();
        try:
            cursor.execute(sql);
            row = cursor.rowcount();
            return  row;
        except Exception as e:
            return e;
        finally:
            cursor.close();

    #执行Sql 返回结果集
    def executSql(self,sql):
        cursor = self.conn.cursor();
        try:
            cursor.execute(sql);
            rs = cursor.fetchmany();
            return rs;
        except Exception as e:
            return e;
        finally:
            cursor.close();

    def executeNonQuery(self,templet, args):
        cursor = self.conn.cursor();
        try:
            cursor.executemany(templet,args);
            row = cursor.rowcount;
            return row;
        except Exception as e:
            return e;
        finally:
            cursor.close();


if __name__ == "__main__":
    my = sqlHelper();
    my.createConnect();
    rs = my.executeScalar("select count(*) from InsurerCompanyInfo where CompanyName =%s", "aa");