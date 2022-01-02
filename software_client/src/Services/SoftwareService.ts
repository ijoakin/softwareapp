export const getSoftware = () => {
  
   const apiUrl = process.env.REACT_APP_BASE_URL + 'api/SoftwareApp';
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


