using ChessGame.Api.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Api.Tests
{
    public class PlayersControllerTests
    {
        public void Generate_New_Player_Id_Should_Return_A_Not_Empty_Guid()
        {
            var controller = new PlayersController();

            Guid newId = controller.GetNewId();

            Assert.AreNotEqual(Guid.Empty, newId);
        }
    }
}
