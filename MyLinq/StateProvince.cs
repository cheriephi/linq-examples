namespace MyLinq
{
    public class StateProvince
    {
        private string stateProvinceCode;
        private string stateProvinceName;

        public StateProvince(string stateProvinceCode, string stateProvinceName)
        {
            this.StateProvinceCode = stateProvinceCode;
            this.StateProvinceName = stateProvinceName;
        }

        public string StateProvinceCode { get => stateProvinceCode; set => stateProvinceCode = value; }
        public string StateProvinceName { get => stateProvinceName; set => stateProvinceName = value; }
    }
}
