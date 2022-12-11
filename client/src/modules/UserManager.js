export const getCurrentUser=()=>{
    const currentUser = localStorage.getItem("pantryUser");
    const pantryUserObject=JSON.parse(currentUser)
    return pantryUserObject;
};

export const login = (userObject) => {
   
    return fetch(`https://localhost:5001/api/User/GetByUNPW?username=${userObject.username}&password=${userObject.password}`)
      .then((r) => r.json())
      .then((userObjFromDB) => {

        localStorage.setItem("pantryUser", JSON.stringify(userObjFromDB));
      
      })
  };

  export const getUserById=(id)=>{
    return fetch(`https://localhost:5001/api/User/${id}`)
    .then(r=>r.json())
  }