namespace Test;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void AddEntityToWorld()
    {
        var entity = new Domain.Entity() {Id = Guid.NewGuid()};
        var world = new Domain.World();
        world.Add(entity);
    }
}