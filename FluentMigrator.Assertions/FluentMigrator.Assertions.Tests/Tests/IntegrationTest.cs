﻿using FluentAssertions;
using FluentMigrator.Assertions.Tests.Setup;
using NUnit.Framework;

namespace FluentMigrator.Assertions.Tests.Tests
{
    [TestFixture]
    public class IntegrationTest : IntegrationTestBase
    {        
        [Test]
        public void TestMethod1()
        {
            RunnerContainer.Runner.Up(new DummyMigration());
            SqlExecutor.TableExists("HelloWorld").Should().BeTrue();
        }
    }

    public class DummyMigration : Migration
    {
        public override void Up()
        {
            Create.Table("HelloWorld").WithColumn("Id").AsInt32().PrimaryKey();
        }

        public override void Down()
        {
            Delete.Table("HelloWorld");
        }
    }
}
