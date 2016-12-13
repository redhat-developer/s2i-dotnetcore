package com.schoolbus.client.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonCreator;
import com.schoolbus.client.model.LocalArea;



import io.swagger.annotations.*;
import java.util.Objects;


public class SchoolDistrict   {
  
  private Integer id = null;
  private LocalArea localArea = null;

  /**
   * Primary Key
   **/
  public SchoolDistrict id(Integer id) {
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
  public SchoolDistrict localArea(LocalArea localArea) {
    this.localArea = localArea;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("LocalArea")
  public LocalArea getLocalArea() {
    return localArea;
  }
  public void setLocalArea(LocalArea localArea) {
    this.localArea = localArea;
  }


  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    SchoolDistrict schoolDistrict = (SchoolDistrict) o;
    return Objects.equals(id, schoolDistrict.id) &&
        Objects.equals(localArea, schoolDistrict.localArea);
  }

  @Override
  public int hashCode() {
    return Objects.hash(id, localArea);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class SchoolDistrict {\n");
    
    sb.append("    id: ").append(toIndentedString(id)).append("\n");
    sb.append("    localArea: ").append(toIndentedString(localArea)).append("\n");
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

