export const getLocations = () => {
  
   const apiUrl = 'https://localhost:5001/api/Location/GetAllLocations';
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