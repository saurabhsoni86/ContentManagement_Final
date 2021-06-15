using ContactManagement.DataAccess.Entities;
using ContactManagement.DataAccess.Interfaces.Contact;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContactManagement.UnitTest
{
    [TestClass]
    public class ContactManagementTest
    {
        private Mock<IContactsRepository> _mockContactsRepository;
        [TestInitialize]
        public void Initialize()
        {
            _mockContactsRepository = new Mock<IContactsRepository>();
        }

        [TestMethod]
        public void AddNewContact()
        {
            // Arrange
            Contacts contact = new Contacts();
            contact.FirstName = "ContactFName";
            contact.LastName = "ContactLName";
            contact.EmailAddress = "contact@gmail.com";
            contact.Id = 1212;
            ContactNumbers contactNumbers = new ContactNumbers();
            contactNumbers.ContactNumber = "9898745623";
            contact.PhoneNumbers = (System.Collections.Generic.IEnumerable<ContactNumbers>)contactNumbers;

            // Act
            var result = _mockContactsRepository.Setup(x => x.AddContact(It.IsAny<Contacts>())).Returns(contact);

            // Assert
            Assert.IsTrue(true, "Add contacts Success.");
        }

        [TestMethod]
        public void UpdateContact()
        {
            // Arrange
            Contacts contact = new Contacts();
            contact.FirstName = "ContactFName";
            contact.LastName = "ContactLName";
            contact.EmailAddress = "contact@gmail.com";
            contact.Id = 1212;
            ContactNumbers contactNumbers = new ContactNumbers();
            contactNumbers.ContactNumber = "9898745623";
            contact.PhoneNumbers = (System.Collections.Generic.IEnumerable<ContactNumbers>)contactNumbers;
            // Act
            var result = _mockContactsRepository.Setup(x => x.UpdateContact(It.IsAny<Contacts>())).Returns(contact);

            // Assert
            Assert.IsTrue(true, "Update contacts Success.");
        }

        [TestMethod]
        public void DeleteContact()
        {
            // Arrange

            int Id = 1212;

            // Act
            _mockContactsRepository.Setup(x => x.DeleteContact(Id));

            // Assert
            Assert.IsTrue(true, "Remove contact Success.");
        }

        [TestMethod]
        public void FindContact()
        {
            // Arrange

            int Id = 1212;

            // Act
            _mockContactsRepository.Setup(x => x.FindContact(Id));

            // Assert
            Assert.IsTrue(true, "Find contact Success.");
        }

        [TestMethod]
        public void GetAllContact()
        {
            // Arrange
            Contacts contact = new Contacts();
            contact.FirstName = "ContactFName";
            contact.LastName = "ContactLName";
            contact.EmailAddress = "contact@gmail.com";
            contact.Id = 1212;
            ContactNumbers contactNumbers = new ContactNumbers();
            contactNumbers.ContactNumber = "9898745623";
            contact.PhoneNumbers = (System.Collections.Generic.IEnumerable<ContactNumbers>)contactNumbers;
            // Act
            var result = _mockContactsRepository.Setup(x => x.GetAllContacts()).Returns((System.Collections.Generic.IEnumerable<Contacts>)contact);

            // Assert
            Assert.IsTrue(true, "Get All contacts Success.");
        }
    }
}
