//
//  SportsPlus
//  Developed by Cristian Lustri
//  Loader.js - Created 20/05/2021
//

// NPM Modules

// Global objects

let STUDENTS_DICTIONARY = {};
let EVENTS_DICTIONARY = {};
let RECORDS_DICTIONARY = {};
let POINTS_DICTIONARY = {};


/**
 * Initializes the Loader
 */
function Initialize() {

    CheckFiles();
    SetLoadingText("Checking Files...");

    LoadStudents();
    SetLoadingText("Loading Students...");

    LoadEvents();
    SetLoadingText("Loading Events...");

    LoadRecords();
    SetLoadingText("Loading Records...");

}

/**
 * Ensures all main files exist, if not creates placeholder files.
 */
function CheckFiles() {
    
}

/**
 * Loads the student CSV into the students object.
 */
function LoadStudents() {
    
}

/**
 * Loads the events CSV into the events object.
 */
function LoadEvents() {

}

/**
 * Loads the records CSV into the records object.
 */
function LoadRecords() {

}

/**
 * Sets Loader status text
 * @param {String} text 
 */
function SetLoadingText(text) {
    document.getElementById("loading-text").innerText = text;
}