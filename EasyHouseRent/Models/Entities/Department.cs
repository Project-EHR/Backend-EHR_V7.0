namespace EasyHouseRent.Models.Entities
{
    public class Department
    {
        BaseData db = new BaseData();
        private int _iddepartamento = 0;
        public int iddepartamento { get { return _iddepartamento; } set { _iddepartamento = value; } }
        private string _nombre = "";
        public string nombre { get { return _nombre; } set { _nombre = value; } }
    }
}
