using System;
using System.Collections.Generic;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace XUnitTests.MockedRepositories {
    class MockedPostRepository : IPostRepository {
        public List<Post> Collection;

        public MockedPostRepository() {
            var post = new Post {
                Id = "mockedId",
                Deadline = new DateTime(),
                Description = "mockedDescription",
                Employer = new Employer(),
                PaymentType = "mockedPaymentType",
                Price = 0.7,
                Title = "mockedTitle"
            };

            Collection = new List<Post> {post, post, post};
        }

        public IEnumerable<Post> All() {
            return Collection;
        }

        public Post Get(string id) {
            return Collection.Find(e => e.Id == id);
        }

        public void Create(Post post) {
            Collection.Add(post);
        }

        public void Update(Post post) {
            var index = Collection.FindIndex(e => e.Id == post.Id);
            Collection[index] = post;
        }

        public void Delete(string id) {
            var index = Collection.FindIndex(e => e.Id == id);
            Collection.RemoveAt(index);
        }
    }
}