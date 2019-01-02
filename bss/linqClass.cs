using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace bss
{
    // Класс для представления CalcData
    [Serializable]
    public class CalcData
    {
        public int Param1;
        public int Param2;
        public int CheckSum;


        public CalcData()
        {
        }

        public CalcData(int p1, int p2, int cs)
        {
            Param1 = p1;
            Param2 = p2;
            CheckSum = cs;
        }
    }


    // Класс для представления OwnerData
    [Serializable]
    public class OwnerData
    {
        public string OwnerName;
        public string OwnerDate;
        public List<CalcData> CalcsData;


        public OwnerData()
        {
        }

        public OwnerData(string n, string d, List<CalcData> c)
        {
            OwnerName = n;
            OwnerDate = d;
            CalcsData = c;
        }
    }


    // Таблица с OwnerData
    [Table]
    public class tbOwner
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int cId { get; set; }
        [Column]
        public string cName { get; set; }
        [Column]
        public string cDate { get; set; }
    }


    // Таблица с CalcsData
    [Table]
    public class tbCalc
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int cId { get; set; }
        [Column]
        public int cParam1 { get; set; }
        [Column]
        public int cParam2 { get; set; }
        [Column]
        public int cChecksum { get; set; }
    }


    // Таблица соответствий: какие CalcsData какому OwnerData принадлежат
    [Table]
    public class tbOwnerCalc
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int cId { get; set; }
        [Column]
        public int cOwnerId { get; set; }
        [Column]
        public int cCalcId { get; set; }
    }


    // Класс для работы с БД
    class linqClass
    {
        public DataContext dtCtx;
        Table<tbOwner> ownerTb;
        Table<tbCalc> calcTb;
        Table<tbOwnerCalc> ownerCalcTb;


        // Конструктор
        // !!! Catalog=db_bss - имя БД в MS SQL Server
        public linqClass()
        {
            dtCtx = new DataContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=db_bss;Integrated Security=True");

            ownerTb = dtCtx.GetTable<tbOwner>();
            calcTb = dtCtx.GetTable<tbCalc>();
            ownerCalcTb = dtCtx.GetTable<tbOwnerCalc>();
        }


        // Сохранение данных в БД
        public bool addNewData(List<OwnerData> listOwners)
        {
            int ownerId = 0;
            int calcId = 0;


            // Перебираю данные из списка
            foreach (OwnerData owner in listOwners)
            {
                try
                {
                    // Создаю новую запись OwnerData и задаю значения
                    tbOwner newOwner = new tbOwner();
                    newOwner.cName = owner.OwnerName;
                    newOwner.cDate = owner.OwnerDate;
                    // Вставляю данные в таблицу и сохраняю изменения
                    ownerTb.InsertOnSubmit(newOwner);
                    dtCtx.SubmitChanges();

                    // Получаю значение cId вставленной записи
                    ownerId = newOwner.cId;

                    // Перебираю данные CalcsData
                    foreach (CalcData one in owner.CalcsData)
                    {
                        // Создаю новую запись CalcData и задаю значения
                        tbCalc newCalc = new tbCalc();
                        newCalc.cParam1 = one.Param1;
                        newCalc.cParam2 = one.Param2;
                        newCalc.cChecksum = one.CheckSum;
                        // Вставляю данные в таблицу и сохраняю изменения
                        calcTb.InsertOnSubmit(newCalc);
                        dtCtx.SubmitChanges();

                        // Получаю значение cId вставленной записи
                        calcId = newCalc.cId;

                        // Добавляю в таблицу новое соответствие: CalcData относится к OwnerData
                        tbOwnerCalc newOwnerCalc = new tbOwnerCalc();
                        newOwnerCalc.cOwnerId = ownerId;
                        newOwnerCalc.cCalcId = calcId;
                        // Вставляю данные в таблицу и сохраняю изменения
                        ownerCalcTb.InsertOnSubmit(newOwnerCalc);
                        dtCtx.SubmitChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при работе с БД:\r\n" + ex.Message, "Ошибка!", MessageBoxButtons.OK);
                    return false;
                }
            }

            return true;
        }


        // Получение данных из БД
        public List<OwnerData> getData()
        {
            List<OwnerData> ownerList = new List<OwnerData>();
            List<CalcData> tmpList = null;


            try
            {
                // Выбираю из БД данные OwnerData
                var owners = from own in ownerTb
                             orderby own.cId
                             select own;

                foreach (var oneOwner in owners)
                {
                    // Для каждого OwnerData выбираю соответствующие ему CalcsData
                    var calcs = from calc in calcTb
                                from ownCalc in ownerCalcTb
                                where calc.cId == ownCalc.cCalcId && ownCalc.cOwnerId == oneOwner.cId
                                orderby calc.cId
                                select calc;

                    // Добавляю значения во временный список с CalcsData
                    tmpList = new List<CalcData>();
                    foreach (var oneCalc in calcs)
                        tmpList.Add(new CalcData(oneCalc.cParam1, oneCalc.cParam2, oneCalc.cChecksum));
                    
                    // Добавляю значения в список с OwnerData
                    ownerList.Add(new OwnerData(oneOwner.cName, oneOwner.cDate, tmpList));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при работе с БД:\r\n" + ex.Message, "Ошибка!", MessageBoxButtons.OK);
                ownerList = null;
            }

            return ownerList;
        }
    }
}
