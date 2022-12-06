export const getCurrentUser=()=>{
    const currentUser = localStorage.getItem("pantryUser");
    return currentUser;
};

export const login = (userObject) => {
   
    return fetch(`https://localhost:44396/api/User/GetByUNPW?username=${userObject.username}&password=${userObject.password}`)
      .then((r) => r.json())
      .then((userObjFromDB) => {

        localStorage.setItem("pantryUser", JSON.stringify(userObjFromDB));
      
      })
  };