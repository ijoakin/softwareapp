import logo from "./logo.svg";
import { NavLink, Route, Routes } from "react-router-dom";
import "./App.css";
import { MenuComponent } from "./Components/MenuComponent";
import { SoftwareComponent } from "./Components/SoftwareComponent";
import "bootstrap/dist/css/bootstrap.min.css";
import { Dropdown } from "react-bootstrap";
import DropdownToggle from "react-bootstrap/esm/DropdownToggle";
import DropdownMenu from "react-bootstrap/esm/DropdownMenu";
import { HomeComponent } from "./Components/HomeComponent";
import { LocationComponent } from "./Components/LocationComponent";
import { PlatformComponent } from "./Components/PlatformComponent";
import { SoftwarePaginatedComponent } from "./Components/SoftwarePaginatedComponent";
import { SoftwareTypesComponent } from "./Components/SoftwareTypesComponent";

function App() {
  return (
    <div>
      <header></header>
      {/*after end of header*/}
      <div className="navbar navbar-expand-lg navbar-light bg-light">
        <Dropdown>
          <Dropdown.Toggle
            id="dropdown-button-dark-example1"
            variant="secondary"
          >
            Menu
          </Dropdown.Toggle>

          <Dropdown.Menu variant="dark">
            <Dropdown.Item href="/Home">Home</Dropdown.Item>
            <Dropdown.Item href="/SoftwareComponent">
              List of Software
            </Dropdown.Item>
            <Dropdown.Item href="/SoftwarePaginatedComponent">
              Software Paginated
            </Dropdown.Item>
            <Dropdown.Item href="/Locations">Locations</Dropdown.Item>
            <Dropdown.Divider />
            <Dropdown.Item href="/Platform">Platforms</Dropdown.Item>
            <Dropdown.Item href="/SoftwareTypesComponent">
              Software Types
            </Dropdown.Item>
          </Dropdown.Menu>
        </Dropdown>
      </div>
      <div className="App-intro">
        <Routes>
          <Route path="/home" element={<HomeComponent></HomeComponent>} />
          <Route
            path="/SoftwareComponent"
            element={<SoftwareComponent></SoftwareComponent>}
          />
          <Route
            path="/Locations"
            element={<LocationComponent></LocationComponent>}
          />
          <Route
            path="/Platform"
            element={<PlatformComponent></PlatformComponent>}
          />
          <Route
            path="/SoftwarePaginatedComponent"
            element={<SoftwarePaginatedComponent></SoftwarePaginatedComponent>}
          />
          <Route
            path="/SoftwareTypesComponent"
            element={<SoftwareTypesComponent></SoftwareTypesComponent>}
          />

          <Route path="/" element={<HomeComponent></HomeComponent>} />
        </Routes>
      </div>
    </div>
  );
}

export default App;
