/* eslint-disable array-callback-return */
import axios from "axios";
import { SSL_OP_SSLEAY_080_CLIENT_DH_BUG } from "constants";
import { useState, useEffect } from "react";
import { Button, Modal } from "react-bootstrap";
import { LocationObject } from "../Model/LocationObject";
import { Platform } from "../Model/Platform";
import { Software } from "../Model/Software";
import { SoftwareType } from "../Model/SoftwareType";
import { getLocations } from "../Services/LocationService";
import { getPlatforms } from "../Services/PlatformService";
import getSoftwareTypes from "../Services/SoftwareTypeService";
import PaginationComponent from "./PaginationComponent";
import { SoftwareGridComponent } from "./SoftwareGridComponent";

export const SoftwarePaginatedComponent = () => {
  var softwares: Software[] = [];
  const filterTypes: SoftwareType[] = [];
  let software: Software = {
    id: 0,
    locationid: 1,
    platformid: 1,
    softwareDescription: "",
    softwareName: "",
    typeid: 1,
    unc: "",
    locationDescription: "",
    platformDescription: "",
    typeDescription: "",
  };

  const [posts, setPosts] = useState(softwares);
  const [loading, setLoading] = useState(false);
  const [soft, setSoftware] = useState(software);
  const [softFilter, setSoftwareFilter] = useState(software);
  const [currentPage, setCurrentPage] = useState(1);
  const [itemsPerPage, setItemsPerPage] = useState(10);
  const [platforms, setPlatforms] = useState([]);
  const [locations, setLocations] = useState([]);
  const [softwareTypes, setSoftwareTypes] = useState([]);
  const indexOfLastPost = currentPage * itemsPerPage;
  const indexOfFirstPost = indexOfLastPost - itemsPerPage;
  const currentPosts = posts.slice(indexOfFirstPost, indexOfLastPost);
  const [softwareFilterTypes, setsoftwareFilterTypes] = useState(filterTypes);

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

  function getAllSoftwareTypes() {
    getSoftwareTypes().then((response: any) => {
      setSoftwareTypes(response);
    });
  }

  function getAllsoftwareFilterTypes() {
    const filterTypes: SoftwareType[] = [];

    const blankSoftwareType: SoftwareType = {
      description: "",
      id: 0,
    };

    filterTypes.push(blankSoftwareType);

    getSoftwareTypes().then((response: any) => {
      response.map((softwareType: SoftwareType) => {
        filterTypes.push(softwareType);
      });
      setsoftwareFilterTypes(filterTypes);
    });
  }

  const fetchSoftware = async () => {
    setLoading(true);

    const url = "https://localhost:5001/api/SoftwareApp/GetSoftware";
    const res = await axios.get(url, {
      params: {
        name: softFilter.softwareName,
        typeId: softFilter.typeid,
      },
    });

    setPosts(res.data);
    setLoading(false);
  };
  useEffect(() => {
    fetchSoftware();
    getAllLocations();
    getAllPlatforms();
    getAllSoftwareTypes();
    getAllsoftwareFilterTypes();
    setSoftware(software);
  }, []);

  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);

  const handleFilter = async () => {
    setCurrentPage(1);
    fetchSoftware();
  };

  const handleClearFilter = async () => {
    const softwareFilter = { ...softFilter };

    softwareFilter.softwareName = "";
    softwareFilter.typeid = 0;
    setCurrentPage(1);

    await setSoftwareFilter(softwareFilter);
  };

  const handleSave = async () => {
    const url = "https://localhost:5001/api/SoftwareApp/SaveSoftware";

    const softwareToSave = { ...soft };
    axios
      .post(url, softwareToSave)
      .then((response) => {
        console.log("saved");
        fetchSoftware();
      })
      .catch((error) => {
        //element.parentElement.innerHTML = `Error: ${error.message}`;
        console.error("There was an error!", error);
      });

    setShow(false);
  };
  const handleShow = () => setShow(true);

  const handleDelete = (i: number) => {
    const url =
      "https://localhost:5001/api/SoftwareApp/DeleteSoftwareById/" + i;
    axios
      .delete(url)
      .then((response) => {
        console.log("deleted");
        fetchSoftware();
      })
      .catch((error) => {
        //element.parentElement.innerHTML = `Error: ${error.message}`;
        console.error("There was an error!", error);
      });

    //console.log("Delete:" + i);
  };
  const OnPaginate = (i: number) => {
    setCurrentPage(i);
  };

  const handleInputFilterChange = (event: any) => {
    const softwareFilter = { ...softFilter };

    switch (event.target.name) {
      case "txtNameFilter":
        softwareFilter.softwareName = event.target.value;
        break;
      case "seltypeidFilter":
        softwareFilter.typeid = event.target.value;
        break;
    }

    setSoftwareFilter(softwareFilter);
  };

  const handleInputChange = (event: any) => {
    software = { ...soft };
    switch (event.target.name) {
      case "txtUnc":
        software.unc = event.target.value;
        break;
      case "selLocationid":
        software.locationid = event.target.value;
        break;
      case "txtName":
        software.softwareName = event.target.value;
        break;
      case "txtDescription":
        software.softwareDescription = event.target.value;
        break;
      case "selPlatformid":
        software.platformid = event.target.value;
        break;
      case "seltypeid":
        software.typeid = event.target.value;
        break;
    }

    setSoftware(software);
  };

  return (
    <div>
      <h1>List of Software</h1>

      <div className="row">
        <div className="col-3">
          <label>Name</label>
          <input
            type="text"
            className="form-control "
            name="txtNameFilter"
            value={softFilter.softwareName}
            onChange={handleInputFilterChange}
          />
        </div>
        <div className="col-3">
          <label>Software Type</label>
          <select
            className="form-control"
            name="seltypeidFilter"
            value={softFilter.typeid}
            onChange={handleInputFilterChange}
          >
            {softwareFilterTypes.map((softwareType: SoftwareType) => (
              <option value={softwareType.id}>
                {softwareType.description}
              </option>
            ))}
          </select>
        </div>
        <div className="col-3">
          <Button className="mt-4" variant="primary" onClick={handleFilter}>
            Filter
          </Button>
          <Button
            className="mt-4 ml-12"
            variant="primary"
            onClick={handleClearFilter}
          >
            Clear Filter
          </Button>
        </div>
      </div>

      <SoftwareGridComponent
        softwares={currentPosts}
        Loading={loading}
        delete={handleDelete}
      ></SoftwareGridComponent>
      <PaginationComponent
        itemsPerPage={itemsPerPage}
        totalItems={posts.length}
        paginate={OnPaginate}
      ></PaginationComponent>
      <div className="mt-3">
        <Button variant="primary" onClick={handleShow}>
          Add new Software
        </Button>
      </div>
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Add new Software</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <label>unc</label>
          <input
            type="text"
            className="form-control"
            name="txtUnc"
            value={soft.unc}
            onChange={handleInputChange}
          />
          <label>Name</label>
          <input
            type="text"
            className="form-control"
            name="txtName"
            value={soft.softwareName}
            onChange={handleInputChange}
          />
          <label>Description</label>
          <input
            type="text"
            className="form-control"
            name="txtDescription"
            value={soft.softwareDescription}
            onChange={handleInputChange}
          />
          <label>Platform</label>
          <select
            className="form-control"
            name="selPlatformid"
            value={soft.platformid}
            onChange={handleInputChange}
          >
            {platforms.map((platform: Platform) => (
              <option value={platform.id}>{platform.description}</option>
            ))}
          </select>
          <label>Location</label>
          <select
            className="form-control"
            name="selLocationid"
            value={soft.locationid}
            onChange={handleInputChange}
          >
            {locations.map((location: LocationObject) => (
              <option value={location.id}>
                {location.description}-{location.physicallocation}
              </option>
            ))}
          </select>

          <label>Software Type</label>
          <select
            className="form-control"
            name="seltypeid"
            value={soft.typeid}
            onChange={handleInputChange}
          >
            {softwareTypes.map((softwareType: SoftwareType) => (
              <option value={softwareType.id}>
                {softwareType.description}
              </option>
            ))}
          </select>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button variant="primary" onClick={handleSave}>
            Save Changes
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};
