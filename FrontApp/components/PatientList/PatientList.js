// @flow

import React from "react";
import {Patient} from "components/Patient";
import {PatientModel} from "models/PatientModel";
import {PatientListModel} from "models/PatientListModel";
import {PatientSearch} from "components/PatientSearch";
import {serverDomain} from "constants/server";
import "./style.css"
import {PatientInput} from "components/PatientInput";


type Props = {};

type State = {
    patients: PatientListModel
};

export class PatientList extends React.Component<Props, State> {
    constructor() {
        super();
        this.state = {
            patients: [],
            filteredPatients:[],
        };
        this.filterList = this.filterList.bind(this);
    }

    componentDidMount() {
        fetch(`${serverDomain}/patients`).then(response => {
            return response.json();
        }).then(res => {
            console.log(res);
            let patientsWithNames = res.data.patients.list;
            patientsWithNames.forEach(patient => {
                patient.fullName = `${patient.firstName} ${patient.lastName}`
            });
            this.setState({
                patients: patientsWithNames,
                filteredPatients:patientsWithNames
            });
        });
    }

    filterList(text) {
        let filteredList = this.state.patients.filter(patient => {
            return patient.fullName.toLowerCase().search(text.toLowerCase()) !== -1;
        });
        this.setState({filteredPatients: filteredList});
    }


    sort() {
    }

    render() {
        return (
            <div className="patient-list">
                <PatientInput/>
                <PatientSearch filter={this.filterList}/>
                <ul>
                    {this.state.patients.length > 0 &&
                    this.state.filteredPatients.map((patient: PatientModel) => {
                        return <Patient setpatientid={this.props.setpatientid} key={patient.patientId} {...patient} />;
                    })}
                </ul>
            </div>
        );
    }
}
