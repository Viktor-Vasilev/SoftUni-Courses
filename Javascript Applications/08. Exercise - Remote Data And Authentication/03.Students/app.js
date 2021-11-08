function attachEvents() {
    getAllStudents();

    document.getElementById("createForm").addEventListener("submit", createStudent);
  }
  
  async function createStudent(event) {
    event.preventDefault();
  
    const formData = new FormData(event.target);

    const firstName = formData.get("firstName");
    const lastName = formData.get("lastName");
    const facultyNumber = formData.get("facultyNumber");
    const grade = formData.get("grade");
    
    const student = {
      firstName,
      lastName,
      facultyNumber,
      grade,
    };
  
    const url = "http://localhost:3030/jsonstore/collections/students";
    await fetch(url, {
      method: "post",
      headers: { "Content-type": "application/json" },
      body: JSON.stringify(student),
    });

    event.target.reset();

    getAllStudents();
  }

  
  async function getAllStudents() {
    const url = "http://localhost:3030/jsonstore/collections/students";
  
    const response = await fetch(url);
    const dataStudents = await response.json();
    console.log(dataStudents);
    console.log(Object.values(dataStudents));
    const rows = Object.values(dataStudents).map(createRow).join("");
    document.querySelector("tbody").innerHTML = rows;
  }
  
  function createRow(student) {
    const result = `
    <tr>
    <th>${student.firstName}</th>
    <th>${student.lastName}</th>
    <th>${student.facultyNumber}</th>
    <th>${student.grade}</th>
  </tr>
    `;
    return result;
  }
  
  attachEvents();