using System;

namespace MVCPattern
{
	class Student
	{
		
		private int rollNo;
		public int RollNo { get { return rollNo; } set { rollNo = value; } }
		
		private string name;
		public string Name { get { return name; } set { name = value; } }

	}

	class StudentView
	{
		public void printStudentDetails(string studentName, int studentRollNo)
		{
			Console.WriteLine("Student: ");
			Console.WriteLine("Name: " + studentName);
			Console.WriteLine("Roll No: " + studentRollNo);
			Console.ReadLine();
		}
	}

	class StudentController
	{
		private Student model;
		private StudentView view;

		public StudentController(Student model, StudentView view)
		{
			this.model = model;
			this.view = view;
		}

		public void setStudentName(string name)
		{
			model.Name = name;
		}

		public string getStudentName()
		{
			return model.Name;
		}

		public void setStudentRollNo(int rollNo)
		{
			model.RollNo = rollNo;
		}

		public int getStudentRollNo()
		{
			return model.RollNo;
		}

		public void updateView()
		{
			view.printStudentDetails(model.Name, model.RollNo);
		}
	}

	class MVCPattern
	{
		static void Main(String[] args)
		{
			Student model = StudentData();

			StudentView view = new StudentView();

			StudentController controller = new StudentController(model, view);

			controller.updateView();

			controller.setStudentName("Vikram Sharma");

			controller.updateView();
		}

		private static Student StudentData()
		{
			Student student = new Student();
			student.Name = "Ashita Rathi";
			student.RollNo = 33;
			return student;
		}

	}

}
