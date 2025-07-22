using Cobra.UnitTesting;
using UnityEngine;
using UnityEngine.Assertions;

namespace Cobra.DesignPattern
{
    public class UT_Command : UnitTest
    {
        [Test]
        public void SingleExecution()
        {
            //Assemble
            CommandHandler cmd = new CommandHandler();
            IntHolder visibility = new IntHolder();

            //Act
            cmd.Execute(new TestCommandSetOne(visibility));

            //Assert
            Assert.AreEqual(visibility.value, 1);
        }

        [Test]
        public void DoubleExecution()
        {
            //Assemble
            CommandHandler cmd = new CommandHandler();
            IntHolder visibility = new IntHolder();

            //Act
            cmd.Execute(new TestCommandSetOne(visibility));
            cmd.Execute(new TestCommandSetSix(visibility));

            //Assert
            Assert.AreEqual(visibility.value, 6);
        }

        [Test]
        public void UndoSingleExecution()
        {
            //Assemble
            CommandHandler cmd = new CommandHandler();
            IntHolder visibility = new IntHolder();

            //Act
            cmd.Execute(new TestCommandSetOne(visibility));
            cmd.Execute(new TestCommandSetSix(visibility));
            cmd.Undo();

            //Assert
            Assert.AreEqual(visibility.value, 1);
        }

        [Test]
        public void UndoDoubleExecution()
        {
            //Assemble
            CommandHandler cmd = new CommandHandler();
            IntHolder visibility = new IntHolder();

            //Act
            cmd.Execute(new TestCommandSetOne(visibility));
            cmd.Execute(new TestCommandSetSix(visibility));
            cmd.Undo();
            cmd.Undo();

            //Assert
            Assert.AreEqual(visibility.value, 0);
        }

        [Test]
        public void RedoSingleExecution()
        {
            //Assemble
            CommandHandler cmd = new CommandHandler();
            IntHolder visibility = new IntHolder();

            //Act
            cmd.Execute(new TestCommandSetOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Undo();
            cmd.Redo();

            //Assert
            Assert.AreEqual(visibility.value, 4);
        }

        [Test]
        public void RedoMultipleExecution()
        {
            //Assemble
            CommandHandler cmd = new CommandHandler();
            IntHolder visibility = new IntHolder();

            //Act
            cmd.Execute(new TestCommandSetOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Undo();
            cmd.Redo();
            cmd.Undo();
            cmd.Redo();
            cmd.Undo();
            cmd.Redo();

            //Assert
            Assert.AreEqual(visibility.value, 4);
        }

        [Test]
        public void RedoHalfPathChangeExecution()
        {
            //Assemble
            CommandHandler cmd = new CommandHandler();
            IntHolder visibility = new IntHolder();

            //Act
            cmd.Execute(new TestCommandSetOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Undo();
            cmd.Redo();
            cmd.Undo();
            cmd.Execute(new TestCommandSetOne(visibility));

            //Assert
            Assert.AreEqual(visibility.value, 1);
        }

        [Test]
        public void RedoFullPathChangeExecution()
        {
            //Assemble
            CommandHandler cmd = new CommandHandler();
            IntHolder visibility = new IntHolder();

            //Act
            cmd.Execute(new TestCommandSetOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Undo();
            cmd.Undo();
            cmd.Undo();
            cmd.Undo();
            cmd.Execute(new TestCommandSetOne(visibility));
            cmd.Undo();
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandSetSix(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));

            //Assert
            Assert.AreEqual(visibility.value, 7);
        }

        [Test]
        public void FalseUndoExecution()
        {
            //Assemble
            CommandHandler cmd = new CommandHandler();
            IntHolder visibility = new IntHolder();
            bool actual = false;

            //Act
            cmd.Execute(new TestCommandSetOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Undo();
            cmd.Undo();
            actual = cmd.Undo();

            //Assert
            Assert.AreEqual(actual, false);
        }

        [Test]
        public void FalseRedoExecution()
        {
            //Assemble
            CommandHandler cmd = new CommandHandler();
            IntHolder visibility = new IntHolder();
            bool actual = false;

            //Act
            cmd.Execute(new TestCommandSetOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Undo();
            cmd.Undo();
            cmd.Execute(new TestCommandSetSix(visibility));
            actual = cmd.Redo();

            //Assert
            Assert.AreEqual(actual, false);
        }

        [Test]
        public void CountSingleExecution()
        {
            //Assemble
            CommandHandler cmd = new CommandHandler();
            IntHolder visibility = new IntHolder();

            //Act
            cmd.Execute(new TestCommandSetOne(visibility));

            //Assert
            Assert.AreEqual(cmd.Count, 1);
        }

        [Test]
        public void CountLargeExecution()
        {
            //Assemble
            CommandHandler cmd = new CommandHandler();
            IntHolder visibility = new IntHolder();

            //Act
            cmd.Execute(new TestCommandSetOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Undo();
            cmd.Undo();
            cmd.Undo();
            cmd.Undo();
            cmd.Execute(new TestCommandSetOne(visibility));
            cmd.Undo();
            cmd.Redo();
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandSetSix(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));

            //Assert
            Assert.AreEqual(cmd.Count, 5);
        }

        [Test]
        public void ClearExecution()
        {
            //Assemble
            CommandHandler cmd = new CommandHandler();
            IntHolder visibility = new IntHolder();

            //Act
            cmd.Execute(new TestCommandSetOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Undo();
            cmd.Undo();
            cmd.Undo();
            cmd.Undo();
            cmd.Execute(new TestCommandSetOne(visibility));
            cmd.Undo();
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Execute(new TestCommandSetSix(visibility));
            cmd.Execute(new TestCommandAddOne(visibility));
            cmd.Clear();

            //Assert
            Assert.AreEqual(cmd.Count, 0);
        }
    }

    public class TestCommandSetOne : Command
    {
        public IntHolder heldValue;

        public TestCommandSetOne(IntHolder ih)
        {
            heldValue = ih;
        }

        private int lastValue;

        public void Execute()
        {
            lastValue = heldValue.value;
            heldValue.value = 1;
        }

        public void Undo()
        {
            heldValue.value = lastValue;
        }
    }

    public class TestCommandSetSix : Command
    {
        public IntHolder heldValue;

        public TestCommandSetSix(IntHolder ih)
        {
            heldValue = ih;
        }

        private int lastValue;

        public void Execute()
        {
            lastValue = heldValue.value;
            heldValue.value = 6;
        }

        public void Undo()
        {
            heldValue.value = lastValue;
        }
    }

    public class TestCommandAddOne : Command
    {
        public IntHolder heldValue;

        public TestCommandAddOne(IntHolder ih)
        {
            heldValue = ih;
        }

        private int lastValue;

        public void Execute()
        {
            heldValue.value += 1;
        }

        public void Undo()
        {
            heldValue.value -= 1;
        }
    }

    public class IntHolder
    {
        public int value = 0;
    }
}