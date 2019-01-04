// @flow

import React from "react";
import {Patient} from "components/Patient";
import {PatientModel} from "models/PatientModel";
import {PatientListModel} from "models/PatientListModel";

type Props = {};

type State = {
    patients: PatientListModel
};

export class PatientList extends React.Component<Props, State> {
    constructor() {
        super();
        this.state = {
            patients: []
        };
    }

    componentDidMount() {
        fetch("https://api.4buttons.ru/v0.1/patients").then(response => {
            return response.json();
        }).then(res => {
            this.setState({
                patients: res.data.patients
            });
        });
    }

    sort() {
    }

    render() {
        return (
            this.state.patients.length > 0 &&
            this.state.patients.map((patient: PatientModel) => {
                return <Patient key={patient.patientId} {...patient} />;
            })
        );
    }
}
