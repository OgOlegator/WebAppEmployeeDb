namespace WebAppEmployeeDb.Data.Models
{
    public class Employee
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string JobTitle { get; set; }        //Todo Сделать внешним ключом для справочника должностей 

        public string Subdivision { get; set; }     //Todo Сделать внешним ключом для справочника подразделений

    }
}
