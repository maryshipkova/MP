// @flow

import React from "react";


export function PatientTimeLineItem(props) {
    return (
        <li>
            <div>
                <input type="number"
                       placeholder="Pef"
                       step="0.01"
                       value={props.leftSide.pef}
                       readOnly={props.leftSide.readOnly}/>
                <input type="number" placeholder="Opf2"
                       step="0.01"
                       value={props.leftSide.opf2}
                       readOnly={props.leftSide.readOnly}/>
                <br/>
                <label>Hospitalized</label>
                <input type="checkbox"
                       checked={props.leftSide.isHospitalized}
                       readOnly={props.leftSide.readOnly}/>
                <br/>
                <label>Wheezing</label>
                <input type="checkbox"
                       checked={props.leftSide.isWheezing}
                       readOnly={props.leftSide.readOnly}/>
            </div>
            <div>
                {props.rightSide}
            </div>
        </li>
    );
}
