using NUnit.Framework;
using NeocronWorldMap.Web.Controllers;
using NeocronWorldMap.Web.Controllers.Actions;
using Rhino.Mocks;

namespace Test.NeocronWorldMap.Web.Controllers.Action
{
    [TestFixture]
    public class TestOutpostOwnedByFactionAction
    {
        [Test]
        public void Sets_ObjectToJsonify_on_controller()
        {
            var outpostOwnedByFactionAction = new OutpostOwnedByFactionAction();

            var jsonViewRenderer = MockRepository.GenerateMock<IRenderJsonViews>();
            outpostOwnedByFactionAction.Execute("05", 'f', jsonViewRenderer);

            jsonViewRenderer
                .AssertWasCalled(
                    x => x.SetJsonObject(Arg<object>.Is.NotNull),
                    c => c.Repeat.Once());
        }
    }
}