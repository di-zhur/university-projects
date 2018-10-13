using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns
{
    /*
     1)Когда процесс создания нового объекта не должен зависеть от того, из каких частей этот объект состоит 
     и как эти части связаны между собой
     2)Когда необходимо обеспечить получение различных вариаций объекта в процессе его создания
    */


    public abstract class Builder
    {
        public abstract void CreateElement1();
        public abstract void CreateElement2();
        public abstract void CreateElement3();
    }

    public class BuildingFirst : Builder
    {
        public override void CreateElement1()
        {
            throw new NotImplementedException();
        }

        public override void CreateElement2()
        {
            throw new NotImplementedException();
        }

        public override void CreateElement3()
        {
            throw new NotImplementedException();
        }
    }

    public class BuildingSecond : Builder
    {
        public override void CreateElement1()
        {
            throw new NotImplementedException();
        }

        public override void CreateElement2()
        {
            throw new NotImplementedException();
        }

        public override void CreateElement3()
        {
            throw new NotImplementedException();
        }
    }

    public class Executor
    {
        private Builder _builder;

        public Executor(Builder builder)
        {
            _builder = builder;
        }

        public void Make()
        {
            _builder.CreateElement1();
            _builder.CreateElement2();
            _builder.CreateElement3();
        }
    }
}
