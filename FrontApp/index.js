// @flow
"use strict";

import React from 'react';
import ReactDom from 'react-dom';
import {PatientList} from 'components/PatientList';
import {PatientInput} from 'components/PatientInput';
import {PatientTimeLine} from "./components/PatientTimeLine";

import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import "./style.css";

class Check extends React.Component {

    constructor(){
        super();
        this.state={
            patientId: 1,
        };
        this.setPatientId = this.setPatientId.bind(this);
    }

    setPatientId(patientId){
        this.setState({
            patientId
        })
    }

    render() {
        return <div className="main-layout">
            <nav className="col-md-2 d-none d-md-block bg-light sidebar"><PatientList activePatient={this.state.patientId} setpatientid={this.setPatientId}/></nav>
            <div className="col-md-9 ml-sm-auto col-lg-10 pt-3 px-4 main full-timeline"><PatientTimeLine patientid={this.state.patientId}/></div>
        </div>;
    }
}

ReactDom.render(
    <Check/>, document.getElementById('app')
);