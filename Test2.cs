using Xunit;
using task02;
namespace task02tests
{
    public class StudentServiceTests
    {
        private List<Student> _testStudents;
        private StudentService _service;

        public void StudentServiceTests()
        {
            _testStudents = new List<Student>
        {
            new() { Name = "Иван", Faculty = "ФИТ", Grades = new List<int> { 5, 4, 5 } },
            new() { Name = "Анна", Faculty = "ФИТ", Grades = new List<int> { 3, 4, 3 } },
            new() { Name = "Петр", Faculty = "Экономика", Grades = new List<int> { 5, 5, 5 } }
        };
            _service = new StudentService(_testStudents);
        }

        [Fact]
        public void GetStudentsByFaculty_ReturnsCorrectStudents()
        {
            var result = _service.GetStudentsByFaculty("ФИТ").ToList();
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.All(s => s.Faculty == "ФИТ"));
        }

        [Fact]
        public void GetStudentsWithMinAverageGrade_ReturnsCorrectStudentsWithAverageGrade()
        {
            var result = _service.GetStudentsWithMinAverageGrade(4.5).ToList();
            Assert.Equal(2, result.Count);
            Assert.All(result, s => Assert.True(s.Grades.Average() >= 4.5));
        }

        [Fact]
        public void GetStudentsOrderedByName_ReturnsCorrectOrderOfNames()
        {
            var result = _service.GetStudentsOrderedByName().ToList();
             Assert.Equal("Анна", result[0].Name);
             Assert.Equal("Иван", result[1].Name);
             Assert.Equal("Петр", result[2].Name);
        }

        [Fact]
        public void GroupStudentsByFaculty_ReturnsCorrectGroups()
        {
            var result = _service.GroupStudentsByFaculty();
            Assert.Equal(2, result["ФИТ"].Count());
            Assert.Equal(1, result["Экономика"].Count());
        }

        [Fact]
        public void GetFacultyWithHighestAverageGrade_ReturnsCorrectFaculty()
        {
            var result = _service.GetFacultyWithHighestAverageGrade();
            Assert.AreEqual("Экономика", result);
        }

    
    }
}
