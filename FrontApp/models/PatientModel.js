// Модель пациента
export class PatientModel {
    
    constructor(
    id: number,
    firstName: string,
    secondName: string,
    middleName: string,
    age: number,
    gender: string,
    image: string){
        this.id = id;
        this.firstName = firstName;
        this.secondName = secondName;
        this.middleName = middleName;
        this.age = age;
        this.gender = gender;
        this.image = image;
    }

    id: number;
    firstName: string;
    secondName: string;
    middleName: string;
    age: number;
    gender: string;
    image: string;
}