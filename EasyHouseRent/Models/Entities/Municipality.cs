namespace EasyHouseRent.Models.Entities
{
    public class Municipality
    {
        BaseData db = new BaseData();
        private int _idmunicipio = 0;
        public int idmunicipio { get { return _idmunicipio; } set { _idmunicipio = value; } }
        private string _nombre = "";
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        private int _departamento = 0;
        public int departamento { get { return _departamento; } set { _departamento = value; } }
    }
}
