import { useState } from "react";
import { Platform } from "../Model/Platform";
import { SoftwareType } from "../Model/SoftwareType";
import { getPlatforms } from "../Services/PlatformService";
import getSoftwareTypes from "../Services/SoftwareTypeService";

export interface MyState {
  data: SoftwareType[];
}
export function SoftwareTypesComponent() {
  const [values, setValues] = useState([]);

  function getAllSoftwareTypes() {
    getSoftwareTypes().then((response: any) => {
      console.log(response);
      setValues(response);
    });
  }

  return (
    <div>
      <h1>List of Software Types</h1>
      <button onClick={() => getAllSoftwareTypes()}>Get Data</button>
      <table className="table">
        <thead>
          <th>Id</th>
          <th>Description</th>
        </thead>
        <tbody>
          {values.map((softwareType: SoftwareType) => (
            <tr>
              <td>{softwareType.id}</td>
              <td>{softwareType.description}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
