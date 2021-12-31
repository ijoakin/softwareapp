import { Button, Modal } from "react-bootstrap";
import { Software } from "../Model/Software";

import { ArrowRight, Pencil, Trash, KanbanFill } from "react-bootstrap-icons";

export interface GridProps {
  softwares: Software[];
  Loading: boolean;
  delete: any;
}

export const SoftwareGridComponent = (props: GridProps) => {
  if (props.Loading) {
    return <h2>Loading ...</h2>;
  }

  return (
    <div>
      <table className="table">
        <thead>
          <th>Id</th>
          <th>softwareName</th>
          <th>Platform</th>
          <th>Location</th>
          <th>Type</th>
          <th>unc</th>
          <th>Description</th>
          <th>Commands</th>
        </thead>
        <tbody>
          {props.softwares.map((software: Software) => (
            <tr>
              <td>{software.id}</td>
              <td>{software.softwareName}</td>
              <td>{software.platformDescription}</td>
              <td>{software.locationDescription}</td>
              <td>{software.typeDescription}</td>
              <td>{software.unc}</td>
              <td>{software.softwareDescription}</td>
              <th>
                <Trash onClick={() => props.delete(software.id)} />
                <Pencil />
              </th>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};
