// @flow

import {sexType} from "types/SexType";

export class PatientModel {
    constructor(
        patientId: number,
        firstName: string,
        secondName: string,
        birthDate: Date,
        sexType: sexType
    ) {

        this.patientId = patientId;
        this.firstName = firstName;
        this.secondName = secondName;
        this.birthDate = birthDate;
        this.sexType = sexType;
    }

    patientId: number;
    firstName: string;
    secondName: string;
    birthDate: Date;
    sexType: sexType;
}
