export const getPlatforms = () => {
  
   const apiUrl = process.env.REACT_APP_BASE_URL + 'api/Platform/GetAllPlatforms';
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