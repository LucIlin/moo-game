using MooGame.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Tests.Mocks
{
    internal class MockScoreResult : IScoreResult
    {
        public bool IsSuccess { get; set; }

        public override string ToString()
        => "RESULT DUMMY";
    }
}
