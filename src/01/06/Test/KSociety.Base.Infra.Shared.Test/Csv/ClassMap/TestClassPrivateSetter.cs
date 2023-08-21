namespace KSociety.Base.Infra.Shared.Test.Csv.ClassMap;

public sealed class TestClassPrivateSetter : CsvHelper.Configuration.ClassMap<Csv.Dto.TestClassPrivateSetter>
{
    public TestClassPrivateSetter()
    {
        this.Map(map => map.Id);
        this.Map(map => map.ClassTypeId);
        this.Map(map => map.Name);
        this.Map(map => map.Ip);
        this.Map(map => map.Enable);
        this.Map(map => map.Ahh);
    }
}
