export const getCurrentUser=()=>{
    const currentUser = localStorage.getItem("pantryUser");

    return currentUser;
};

export const login = (userObject) => {
   
    return fetch(`api/userprofile/getbyemail?email=${userObject.email}`)
      .then((r) => r.json())
      .then((userObjFromDB) => {

        localStorage.setItem("gifterUser", JSON.stringify(userObjFromDB));
      })
  };