import React, {Component} from 'react';
import styled from 'styled-components';
import {FormContainer, Input, Button} from './consts/styles';
import apiFileSorter from '../api/apiFileSorter';

const FileSorterContainer = styled.div`
    width: 400px;
    text-align: center;
    user-select: none;
    
    @media screen and (max-width: 500px) {
        width: 300px;
    }
`;

class FileSorter extends Component {
    constructor(props) {
        super(props);
        this.sortXmlFile = this.sortXmlFile.bind(this);
        this.selectFileHandler = this.selectFileHandler.bind(this);
        this.submitFileHandler = this.submitFileHandler.bind(this);

        this.state = {
            file: ""
        };
    }

    selectFileHandler = (event) => {
        event.preventDefault();
        this.setState({file: event.target.value});
    };

    submitFileHandler = (event) => {
        event.preventDefault();

        const file = {
            file: this.state.file
        };

        this.sortXmlFile(file)
    };

    sortXmlFile = (file) => {
        try {
            apiFileSorter.sortXmlFile(file).then(response => {
                const files = response.data.files;
                this.setState({result: files});
            });
        } catch (e) {
            console.log('Failed to count XML files: ', e);
        }
    };

    render() {
        return (
            <FileSorterContainer>
                <FormContainer>
                    <Input type="text" name="sorter" placeholder="Select a file" onChange={this.selectFileHandler}/>
                    <Button onClick={(event) => this.submitFileHandler(event)}>Submit</Button>
                </FormContainer>
            </FileSorterContainer>
        );
    }
}

export default FileSorter;