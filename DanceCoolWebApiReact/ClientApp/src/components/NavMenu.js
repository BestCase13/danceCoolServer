import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import { AuthenticationModal } from './Authentication/AuthenticationModal';
import Logo from '../assets/lasalsa-logo.png'

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor(props) {
    super(props);
    this.state = {
      authenticationModalVisible: false,
      collapsed: true
    };
    this.AuthenticationMModalVisibilityHandler = this.AuthenticationModalVisibilityHandler.bind(AuthenticationModal);
    this.toggleNavbar = this.toggleNavbar.bind(this);
    
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  AuthenticationModalVisibilityHandler = event => {
    if (this.state.authenticationModalVisible === false) {
      this.setState({ authenticationModalVisible: true });
    }
    else {
      this.setState({ authenticationModalVisible: false });
    }
  }

  render() {
    return (
      <div>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-black border-bottom box-shadow" dark>
          <Container>
            <NavbarBrand tag={Link} to="/">
              <img src={Logo} alt="LaSalsaLogo" />
            </NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/">Головна</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/about-us">Про нас</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/guest-group">Групи</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/schedule">Розклад</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/guest-mentors">Наставники</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/guest-contacts">Контакти</NavLink>
                </NavItem>
                <NavItem>
                  <button className="btn btn-light" onClick={this.AuthenticationModalVisibilityHandler}>Увійти</button>
                </NavItem>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
        <AuthenticationModal
          visible={this.state.authenticationModalVisible}
          close={this.AuthenticationModalVisibilityHandler}
          tabSwitching={this.onAuthenticationSelectTab}
          authenticationButtonText={this.state.AuthenticationButtonText}/>
      </div>
    );
  }
}
