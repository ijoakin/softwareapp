export const getPlatforms = () => {
  
   const apiUrl = 'https://localhost:5001/api/Platform/GetAllPlatforms';
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