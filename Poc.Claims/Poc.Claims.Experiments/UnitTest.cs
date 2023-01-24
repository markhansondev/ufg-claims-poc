using System.Linq;
using Poc.Claims.Experiments.A;
using Poc.Claims.Experiments.B;
using Shouldly;
using Xunit;

namespace Poc.Claims.Experiments
{
    public class UnitTest
    {
        readonly Class1ARepository _class1ARepository = new();
        readonly Class1BRepository _class1BRepository = new();
        readonly Class2BRepository _class2BRepository = new();

        public UnitTest()
        {
            SessionFactory.Init(@"Server=.;Database=ClaimsPocExperiment;Trusted_Connection=true");
        }

        [Fact]
        public void TestA()
        {
            var class1A = new Class1A();
            _class1ARepository.Save(class1A);
            
            //verify
            var savedClass1A = _class1ARepository.LoadWithClass2AsById(class1A.Id); //lazy load
            savedClass1A.Class2As.Count().ShouldBe(2);
            savedClass1A.Class2As.ElementAt(0).Id.ShouldNotBe(0);
        }

        [Fact]
        public void TestB()
        {
            var class1B = new Class1B();
            _class1BRepository.Save(class1B);
            var class2B = _class2BRepository.GetById(class1B.Class2BBriefs.ElementAt(0).Id);
            class2B.AddClass3B();
            _class2BRepository.Save(class2B);

            //verify
            var savedClass1B = _class1BRepository.GetById(class1B.Id);
            var savedClass2B = _class2BRepository.GetById(savedClass1B.Class2BBriefs.ElementAt(0).Id);
            savedClass1B.Class2BBriefs.ElementAt(0).Id.ShouldBe(savedClass2B.Id);
            savedClass2B.Class3Bs.ElementAt(0).Id.ShouldNotBe(0);
        }
    }
}
