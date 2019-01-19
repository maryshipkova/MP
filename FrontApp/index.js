// @flow
"use strict";

import React from 'react';
import ReactDom from 'react-dom';
import {PatientList} from 'components/PatientList';
import {PatientInput} from 'components/PatientInput';
import {PatientTimeLine} from "./components/PatientTimeLine";

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
            <PatientList setpatientid={this.setPatientId}/>
            <PatientTimeLine patientid={this.state.patientId}/>
        </div>;
    }
}

ReactDom.render(
    <Check/>, document.getElementById('app')
);