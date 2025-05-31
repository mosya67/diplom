using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IWriteFunc<TOut, TIn>
    {
        public TOut Write(TIn tin);
    }

    public interface IWriteFunc<TIn>
    {
        public void Write(TIn tin);
    }
}
