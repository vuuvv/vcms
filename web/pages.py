import sqlite3
import adodbapi

ado = adodbapi.connect('Provider=Microsoft.SQLSERVER.CE.OLEDB.4.0; Data Source="vuuvv.sdf"')
ado_cur = ado.cursor()

#ado_cur.execute("update WebPages set parentid=null")
#ado_cur.execute("delete from WebPages")
##data = ado_cur.fetchall()
#
##for d in data:
##    print d
#
lite = sqlite3.connect("test.db")
cur = lite.cursor()
cur.execute("select category_id, title, sub_title, author, press_from, summary, content, is_active, thumbnail, tags, publish_date from press_press")
data = cur.fetchall()

sql = "INSERT INTO Presses(CategoryId, Title, SubTitle, Author, PressFrom, Summary, Content, Active, Thumbnail, Tags, CreatedDate) VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s)"
#sql = "INSERT INTO Test(name) VALUES (?)"
#ado_cur.execute(sql, ("hi", ))
for d in data:
    print type(d), d[0], sql % d
    ado_cur.execute(sql % d)
ado.commit()

lite.close()
ado.close()
