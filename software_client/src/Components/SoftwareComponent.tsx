import React, { Component, useEffect, useState } from "react";
import { Button, Modal } from "react-bootstrap";
import { LocationObject } from "../Model/LocationObject";
import { Platform } from "../Model/Platform";
import { Software } from "../Model/Software";
import { getLocations } from "../Services/LocationService";
import { getPlatforms } from "../Services/PlatformService";
import { getSoftware } from "../Services/SoftwareService";

export interface MyState {
  data: Software[];
  newSoftware: Software;
}

export function SoftwareComponent() {
  // eslint-disable-next-line @typescript-eslint/no-useless-constructor
  const [values, setValues] = useState([]);
  const [platforms, setPlatforms] = useState([]);
  const [locations, setLocations] = useState([]);

  const [newSoftware, setSoftware] = useState({});

  function getAllSoftware() {
    getSoftware().then((response: any) => {
      console.log(response);
      setValues(response);
    });
  }

  function getAllPlatforms() {
    getPlatforms().then((response: any) => {
      console.log(response);
      setPlatforms(response);
    });
  }

  function getAllLocations() {
    getLocations().then((response: any) => {
      console.log(response);
      setLocations(response);
    });
  }

  useEffect(() => {
    // Update the document title using the browser API
    // getAllPlatforms();
    // getAllLocations();
  });

  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);

  const handleSave = () => {
    setShow(false);
  };
  const handleShow = () => setShow(true);

  return (
    <div>
      <h1>List of Software</h1>
      <button onClick={() => getAllSoftware()}>Get Data</button>
      <table className="table">
        <thead>
          <th>Id</th>
          <th>typeid</th>
          <th>locationid</th>
          <th>platformid</th>
          <th>unc</th>
          <th>Description</th>
          <th>softwareName</th>
        </thead>
        <tbody>
          {values.map((software: Software) => (
            <tr>
              <td>{software.id}</td>
              <td>{software.typeid}</td>
              <td>{software.locationid}</td>
              <th>{software.platformid}</th>
              <td>{software.unc}</td>
              <td>{software.softwareDescription}</td>
              <td>{software.softwareName}</td>
            </tr>
          ))}
        </tbody>
      </table>

      <Button variant="primary" onClick={handleShow}>
        Add new Software
      </Button>

      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Add new Software</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <label>unc</label>
          <input type="text" className="form-control" id="txtUnc"></input>
          <label>Name</label>
          <input type="text" className="form-control" id="txtName"></input>
          <label>Platform</label>
          <select className="form-control">
            {platforms.map((platform: Platform) => (
              <option value={platform.id}>{platform.description}</option>
            ))}
          </select>
          <label>Location</label>
          <select className="form-control">
            {locations.map((location: LocationObject) => (
              <option value={location.id}>
                {location.description}-{location.physicallocation}
              </option>
            ))}
          </select>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button variant="primary" onClick={handleClose}>
            Save Changes
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
}
