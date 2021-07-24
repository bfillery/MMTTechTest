using HelloWorld.Fundamentals;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HelloWorld.UnitTests
{
    [TestFixture]
    public class PostTests
    {

        [Test]
        public void AddVote_WhenCalledWithUp_IncrementsVoteCount()
        {
            //arrange
            var post = new Post("My Title", "My Description");
            int ExpectedResult = 2; //2 upvotes

            post.AddVote(Post.VoteDirection.Up, DateTime.Now);
            post.AddVote(Post.VoteDirection.Up, DateTime.Now.AddSeconds(10));

            //act
            var result = post.GetVoteTally();


            //assert
            Assert.That(result, Is.EqualTo(ExpectedResult));
        }

        [Test]
        public void AddVote_WhenCalledWithDown_DecrementsVoteCount()
        {
            //arrange
            var post = new Post("My Title", "My Description");
            int ExpectedResult = 2; //3 upvotes, 1 downvote

            post.AddVote(Post.VoteDirection.Up, DateTime.Now);
            post.AddVote(Post.VoteDirection.Up, DateTime.Now.AddSeconds(10));
            post.AddVote(Post.VoteDirection.Up, DateTime.Now.AddSeconds(20));
            post.AddVote(Post.VoteDirection.Down, DateTime.Now.AddSeconds(30));

            //act
            var result = post.GetVoteTally();


            //assert
            Assert.That(result, Is.EqualTo(ExpectedResult));
        }

        [Test]
        public void AddVote_ZeroVotesDownVote_HasNoEffect()
        {
            //arrange
            var post = new Post("My Title", "My Description");
            int ExpectedResult = 0; //2 upvotes, 3 downvote

            post.AddVote(Post.VoteDirection.Up, DateTime.Now); //1
            post.AddVote(Post.VoteDirection.Up, DateTime.Now.AddSeconds(10)); //2
            post.AddVote(Post.VoteDirection.Down, DateTime.Now.AddSeconds(20)); //1
            post.AddVote(Post.VoteDirection.Down, DateTime.Now.AddSeconds(30)); //0
            post.AddVote(Post.VoteDirection.Down, DateTime.Now.AddSeconds(40)); // still 0

            //act
            var result = post.GetVoteTally();


            //assert
            Assert.That(result, Is.EqualTo(ExpectedResult));
        }

        [Test]
        public void GetVotes_WhenCalled_ReturnsDictionary()
        {
            //arrange
            var post = new Post("My Title", "My Description");

            //act
            var result = post.GetVotes();

            //assert
            Assert.That(result, Is.TypeOf<Dictionary<DateTime, Post.VoteDirection>>());
        }

        [Test]
        public void Indexer_WhenCalled_ReturnsExpectedVote()
        {
            //arrange
            var post = new Post("My Title", "My Description");
            var expectedResult = Post.VoteDirection.Down;

            //act
            DateTime postDate = DateTime.Now.AddSeconds(30);
            post.AddVote(Post.VoteDirection.Up, DateTime.Now); //1
            post.AddVote(Post.VoteDirection.Down, postDate); //2
            var result = post[postDate];

            //assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

       

    }
}
