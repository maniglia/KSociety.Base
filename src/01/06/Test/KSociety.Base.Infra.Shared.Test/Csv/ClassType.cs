namespace KSociety.Base.Infra.Shared.Test.Csv
{
    using System.Collections.Generic;

    public class ClassType
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Mean { get; private set; }

        public virtual ICollection<DtoTestClass3> DtoTestClass3s { get; set; }

        public ClassType(int id, string name, string mean)
        {
            this.Id = id;
            this.Name = name;
            this.Mean = mean;
        }
    }
}
