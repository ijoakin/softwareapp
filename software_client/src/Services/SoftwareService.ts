export const getSoftware = () => {
  
   const apiUrl = 'https://localhost:5001/api/SoftwareApp';
     return fetch(apiUrl,
        {
          method: 'GET',
          mode: "cors",
          headers: {
            'Content-Type': 'application/json'           
          }
        })
        .then(res => res.json());
}


