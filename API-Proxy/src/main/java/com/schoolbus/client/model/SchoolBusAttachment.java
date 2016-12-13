package com.schoolbus.client.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonCreator;
import com.schoolbus.client.model.SchoolBus;



import io.swagger.annotations.*;
import java.util.Objects;


public class SchoolBusAttachment   {
  
  private Integer id = null;
  private SchoolBus schoolBus = null;

  /**
   * Primary Key
   **/
  public SchoolBusAttachment id(Integer id) {
    this.id = id;
    return this;
  }

  
  @ApiModelProperty(example = "null", required = true, value = "Primary Key")
  @JsonProperty("Id")
  public Integer getId() {
    return id;
  }
  public void setId(Integer id) {
    this.id = id;
  }

  /**
   **/
  public SchoolBusAttachment schoolBus(SchoolBus schoolBus) {
    this.schoolBus = schoolBus;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("SchoolBus")
  public SchoolBus getSchoolBus() {
    return schoolBus;
  }
  public void setSchoolBus(SchoolBus schoolBus) {
    this.schoolBus = schoolBus;
  }


  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    SchoolBusAttachment schoolBusAttachment = (SchoolBusAttachment) o;
    return Objects.equals(id, schoolBusAttachment.id) &&
        Objects.equals(schoolBus, schoolBusAttachment.schoolBus);
  }

  @Override
  public int hashCode() {
    return Objects.hash(id, schoolBus);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class SchoolBusAttachment {\n");
    
    sb.append("    id: ").append(toIndentedString(id)).append("\n");
    sb.append("    schoolBus: ").append(toIndentedString(schoolBus)).append("\n");
    sb.append("}");
    return sb.toString();
  }

  /**
   * Convert the given object to string with each line indented by 4 spaces
   * (except the first line).
   */
  private String toIndentedString(Object o) {
    if (o == null) {
      return "null";
    }
    return o.toString().replace("\n", "\n    ");
  }
}

