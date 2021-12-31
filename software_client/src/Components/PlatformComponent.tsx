import { useState } from "react";
import { Platform } from "../Model/Platform";
import { getPlatforms } from "../Services/PlatformService";

export interface MyState {
  data: Platform[];
}
export function PlatformComponent() {
  const [values, setValues] = useState([]);

  function getAllSoftware() {
    getPlatforms().then((response: any) => {
      console.log(response);
      setValues(response);
    });
  }

  return (
    <div>
      <h1>List of Platforms</h1>
      <button onClick={() => getAllSoftware()}>Get Data</button>
      <table className="table">
        <thead>
          <th>Id</th>
          <th>Description</th>
        </thead>
        <tbody>
          {values.map((platform: Platform) => (
            <tr>
              <td>{platform.id}</td>
              <td>{platform.description}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
