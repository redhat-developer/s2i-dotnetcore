package com.schoolbus.client.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonCreator;
import com.schoolbus.client.model.OwnerContact;



import io.swagger.annotations.*;
import java.util.Objects;


public class OwnerContactAddress   {
  
  private Integer id = null;
  private OwnerContact ownerContact = null;

  /**
   * Primary Key
   **/
  public OwnerContactAddress id(Integer id) {
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
  public OwnerContactAddress ownerContact(OwnerContact ownerContact) {
    this.ownerContact = ownerContact;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("OwnerContact")
  public OwnerContact getOwnerContact() {
    return ownerContact;
  }
  public void setOwnerContact(OwnerContact ownerContact) {
    this.ownerContact = ownerContact;
  }


  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    OwnerContactAddress ownerContactAddress = (OwnerContactAddress) o;
    return Objects.equals(id, ownerContactAddress.id) &&
        Objects.equals(ownerContact, ownerContactAddress.ownerContact);
  }

  @Override
  public int hashCode() {
    return Objects.hash(id, ownerContact);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class OwnerContactAddress {\n");
    
    sb.append("    id: ").append(toIndentedString(id)).append("\n");
    sb.append("    ownerContact: ").append(toIndentedString(ownerContact)).append("\n");
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

