using System;
using System.Collections.Generic;
using WorkAround.Data.Entities;
using WorkAround.Data.Interfaces;

namespace XUnitTests.MockedRepositories {
    class MockedEmployerRepository : IEmployerRepository {
        public List<Employer> Collection;

        public MockedEmployerRepository() {
            var employer = new Employer();
            employer.JobConditions = "mockedJobConditions";

            var post = new Post {
                Id = "mockedId",
                Deadline = new DateTime(),
                Description = "mockedDescription",
                Employer = new Employer(),
                PaymentType = "mockedPaymentType",
                Price = 0.7,
                Title = "mockedTitle"
            };

            employer.Posts = new List<Post> {post, post, post};

            employer.User = new User();
            employer.UserId = "mockedUserId";
            employer.Proffesion = new Proffesion();

            Collection = new List<Employer> {employer, employer, employer};
        }

        public IEnumerable<Employer> All() {
            return Collection;
        }

        public Employer GetEmployerById(string id) {
            return Collection.Find(e => e.UserId == id);
        }

        public void Create(Employer employer) {
            Collection.Add(employer);
        }

        public void Update(Employer employer) {
            var index = Collection.FindIndex(e => e.UserId == employer.UserId);
            Collection[index] = employer;
        }

        public void Delete(string id) {
            var index = Collection.FindIndex(e => e.UserId == id);
            Collection.RemoveAt(index);
        }
    }
}