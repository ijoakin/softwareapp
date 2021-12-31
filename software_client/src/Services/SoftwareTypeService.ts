const getSoftwareTypes = () => {
  
   const apiUrl = 'https://localhost:5001/api/SoftwareType/GetAllSoftwareTypes';
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

export default getSoftwareTypes;