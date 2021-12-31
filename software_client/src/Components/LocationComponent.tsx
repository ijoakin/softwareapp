import { useState } from "react";
import { LocationObject } from "../Model/LocationObject";
import { getLocations } from "../Services/LocationService";

export function LocationComponent() {
  const [values, setValues] = useState([]);

  function getAllLocations() {
    getLocations().then((response: any) => {
      console.log(response);
      setValues(response);
    });
  }

  return (
    <div>
      <h1>List of Locations</h1>
      <button onClick={() => getAllLocations()}>Get Data</button>
      <table className="table">
        <thead>
          <th>Id</th>
          <th>physicallocation</th>
          <th>Description</th>
        </thead>
        <tbody>
          {values.map((location: LocationObject) => (
            <tr>
              <td>{location.id}</td>
              <td>{location.physicallocation}</td>
              <td>{location.description}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
